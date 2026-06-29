using ABMS_2026.Data.MySql;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ABMS_2026.Common.Printing
{
    public class ITRPrint
    {
        private readonly int _biteCaseId;
        private readonly MySqlConnectionHelper _connectionHelper;
        private PrintDocument? _printDocument;
        private int _currentPage;
        private int _totalPages = 2;

        private PatientData _patientData = new();
        private BiteCaseData _biteCaseData = new();
        private DoctorOrderData _doctorOrderData = new();
        private ProphylaxisHistoryData _prophylaxisHistoryData = new();
        private List<TreatmentScheduleData> _treatmentSchedules = new();
        private List<CategoryBasisData> _categoryBasisList = new();

        private Image? _patientImage;
        private Image? _biteChartImage;
        private Image? _logoImage;

        private readonly Font _headerFont = new Font("Arial", 14, FontStyle.Bold);
        private readonly Font _subHeaderFont = new Font("Arial", 11, FontStyle.Bold);
        private readonly Font _sectionHeaderFont = new Font("Arial", 10, FontStyle.Bold);
        private readonly Font _normalFont = new Font("Arial", 8);
        private readonly Font _boldFont = new Font("Arial", 8, FontStyle.Bold);
        private readonly Font _smallFont = new Font("Arial", 7);

        private readonly Color _headerBackColor = Color.FromArgb(91, 155, 213);
        private readonly Color _headerBorderColor = Color.FromArgb(255, 230, 0);
        private readonly Color _sectionHeaderBackColor = Color.FromArgb(91, 155, 213);

        public ITRPrint(int biteCaseId)
        {
            _biteCaseId = biteCaseId;
            _connectionHelper = new MySqlConnectionHelper();
        }

        public void Print()
        {
            if (!LoadData())
            {
                MessageBox.Show(
                    "Failed to load data for printing.",
                    "Print Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            ConfigurePrintDocument();
            ShowPrintPreview();
        }

        private void ConfigurePrintDocument()
        {
            if (_printDocument != null)
            {
                _printDocument.BeginPrint -= PrintDocument_BeginPrint;
                _printDocument.PrintPage -= PrintDocument_PrintPage;
                _printDocument.Dispose();
            }

            _printDocument = new PrintDocument
            {
                DefaultPageSettings =
                {
                    Landscape = false,
                    Margins = new Margins(20, 20, 20, 20)
                },
                OriginAtMargins = true
            };

            _printDocument.BeginPrint += PrintDocument_BeginPrint;
            _printDocument.PrintPage += PrintDocument_PrintPage;
        }

        private void PrintDocument_BeginPrint(object sender, PrintEventArgs e)
        {
            _currentPage = 0;
        }

        private void ShowPrintPreview()
        {
            using var previewDialog = new PrintPreviewDialog
            {
                Document = _printDocument,
                UseAntiAlias = true,
                WindowState = FormWindowState.Maximized,
                StartPosition = FormStartPosition.CenterScreen,
                ShowIcon = false,
                MinimizeBox = false,
                MaximizeBox = true
            };

            previewDialog.PrintPreviewControl.Zoom = 1.0;
            previewDialog.PrintPreviewControl.AutoZoom = false;

            previewDialog.ShowDialog();
        }

        private bool LoadData()
        {
            try
            {
                _patientData = LoadPatientData();
                _biteCaseData = LoadBiteCaseData();
                _doctorOrderData = LoadDoctorOrderData();
                _prophylaxisHistoryData = LoadProphylaxisHistoryData();
                _treatmentSchedules = LoadTreatmentSchedules();
                _categoryBasisList = LoadCategoryBasis();
                _patientImage = LoadPatientImage();
                _biteChartImage = LoadBiteChartImage();
                _logoImage = LoadLogoImage();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error loading data: {ex.Message}",
                    "Load Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
        }

        private PatientData LoadPatientData()
        {
            using var connection = _connectionHelper.GetConnection();
            connection.Open();

            const string sql = @"
SELECT
    p.patient_id,
    p.registration_no,
    p.last_name,
    p.first_name,
    p.middle_name,
    p.birth_date,
    p.age,
    p.sex,
    p.civil_status,
    p.address,
    p.contact_no,
    p.weight,
    p.image
FROM patients p
INNER JOIN bite_cases bc ON p.patient_id = bc.patient_id
WHERE bc.bite_case_id = @bite_case_id
LIMIT 1;";

            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@bite_case_id", _biteCaseId);

            using var reader = command.ExecuteReader();
            if (!reader.Read())
                return new PatientData();

            return new PatientData
            {
                PatientId = reader["patient_id"] != DBNull.Value ? Convert.ToInt32(reader["patient_id"]) : 0,
                RegistrationNo = reader["registration_no"]?.ToString() ?? string.Empty,
                LastName = reader["last_name"]?.ToString() ?? string.Empty,
                FirstName = reader["first_name"]?.ToString() ?? string.Empty,
                MiddleName = reader["middle_name"]?.ToString() ?? string.Empty,
                BirthDate = reader["birth_date"] != DBNull.Value ? Convert.ToDateTime(reader["birth_date"]) : (DateTime?)null,
                Age = reader["age"] != DBNull.Value ? Convert.ToInt32(reader["age"]) : (int?)null,
                Sex = reader["sex"]?.ToString() ?? string.Empty,
                CivilStatus = reader["civil_status"]?.ToString() ?? string.Empty,
                Address = reader["address"]?.ToString() ?? string.Empty,
                ContactNo = reader["contact_no"]?.ToString() ?? string.Empty,
                Weight = reader["weight"] != DBNull.Value ? Convert.ToDecimal(reader["weight"]) : (decimal?)null,
                ImageBytes = reader["image"] != DBNull.Value ? (byte[])reader["image"] : null
            };
        }

        private BiteCaseData LoadBiteCaseData()
        {
            using var connection = _connectionHelper.GetConnection();
            connection.Open();

            const string sql = @"
SELECT
    bite_case_id,
    exposure_date,
    incident_place,
    animal_type,
    animal_classification,
    animal_status,
    is_wound_washed,
    wound_type,
    wound_count,
    wound_classification,
    bite_locations,
    bite_chart_path,
    remarks
FROM bite_cases
WHERE bite_case_id = @bite_case_id
LIMIT 1;";

            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@bite_case_id", _biteCaseId);

            using var reader = command.ExecuteReader();
            if (!reader.Read())
                return new BiteCaseData();

            return new BiteCaseData
            {
                ExposureDate = reader["exposure_date"] != DBNull.Value ? Convert.ToDateTime(reader["exposure_date"]) : (DateTime?)null,
                IncidentPlace = reader["incident_place"]?.ToString() ?? string.Empty,
                AnimalType = reader["animal_type"]?.ToString() ?? string.Empty,
                AnimalClassification = reader["animal_classification"]?.ToString() ?? string.Empty,
                AnimalStatus = reader["animal_status"]?.ToString() ?? string.Empty,
                IsWoundWashed = reader["is_wound_washed"] != DBNull.Value && Convert.ToBoolean(reader["is_wound_washed"]),
                WoundType = reader["wound_type"]?.ToString() ?? string.Empty,
                WoundCount = reader["wound_count"]?.ToString() ?? string.Empty,
                WoundClassification = reader["wound_classification"]?.ToString() ?? string.Empty,
                BiteLocations = reader["bite_locations"]?.ToString() ?? string.Empty,
                BiteChartPath = reader["bite_chart_path"]?.ToString() ?? string.Empty,
                Remarks = reader["remarks"]?.ToString() ?? string.Empty
            };
        }

        private DoctorOrderData LoadDoctorOrderData()
        {
            using var connection = _connectionHelper.GetConnection();
            connection.Open();

            const string sql = @"
SELECT
    doctor_order_id,
    history_present_illness,
    physical_examination,
    diagnosis,
    management,
    other_management,
    medication_antibiotic,
    medication_nsaid,
    medication_others,
    is_pep,
    is_prep,
    prep_details,
    `is_erig`,
    erig_details,
    `is_hrig`,
    hrig_details,
    is_tetanus_diphtheria,
    is_tetanus_toxoid,
    tetanus_toxoid_details,
    is_anti_tetanus_serum,
    anti_tetanus_serum_details,
    doctor_name
FROM doctor_orders
WHERE bite_case_id = @bite_case_id
LIMIT 1;";

            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@bite_case_id", _biteCaseId);

            using var reader = command.ExecuteReader();
            if (!reader.Read())
                return new DoctorOrderData();

            return new DoctorOrderData
            {
                HistoryPresentIllness = reader["history_present_illness"]?.ToString() ?? string.Empty,
                PhysicalExamination = reader["physical_examination"]?.ToString() ?? string.Empty,
                Diagnosis = reader["diagnosis"]?.ToString() ?? string.Empty,
                Management = reader["management"]?.ToString() ?? string.Empty,
                OtherManagement = reader["other_management"]?.ToString() ?? string.Empty,
                MedicationAntibiotic = reader["medication_antibiotic"]?.ToString() ?? string.Empty,
                MedicationNsaid = reader["medication_nsaid"]?.ToString() ?? string.Empty,
                MedicationOthers = reader["medication_others"]?.ToString() ?? string.Empty,
                IsPep = reader["is_pep"] != DBNull.Value && Convert.ToBoolean(reader["is_pep"]),
                IsPrep = reader["is_prep"] != DBNull.Value && Convert.ToBoolean(reader["is_prep"]),
                PrepDetails = reader["prep_details"]?.ToString() ?? string.Empty,
                IsErig = reader["is_erig"] != DBNull.Value && Convert.ToBoolean(reader["is_erig"]),
                ErigDetails = reader["erig_details"]?.ToString() ?? string.Empty,
                IsHrig = reader["is_hrig"] != DBNull.Value && Convert.ToBoolean(reader["is_hrig"]),
                HrigDetails = reader["hrig_details"]?.ToString() ?? string.Empty,
                IsTetanusDiphtheria = reader["is_tetanus_diphtheria"] != DBNull.Value && Convert.ToBoolean(reader["is_tetanus_diphtheria"]),
                IsTetanusToxoid = reader["is_tetanus_toxoid"] != DBNull.Value && Convert.ToBoolean(reader["is_tetanus_toxoid"]),
                TetanusToxoidDetails = reader["tetanus_toxoid_details"]?.ToString() ?? string.Empty,
                IsAntiTetanusSerum = reader["is_anti_tetanus_serum"] != DBNull.Value && Convert.ToBoolean(reader["is_anti_tetanus_serum"]),
                AntiTetanusSerumDetails = reader["anti_tetanus_serum_details"]?.ToString() ?? string.Empty,
                DoctorName = reader["doctor_name"]?.ToString() ?? string.Empty
            };
        }

        private ProphylaxisHistoryData LoadProphylaxisHistoryData()
        {
            using var connection = _connectionHelper.GetConnection();
            connection.Open();

            const string sql = @"
SELECT
    prophylaxis_history_id,
    bite_case_id,
    date_given,
    vaccine_brand,
    route,
    is_hrig_given,
    is_booster,
    pep_completed_date,
    consent_notes
FROM prophylaxis_history
WHERE bite_case_id = @bite_case_id
LIMIT 1;";

            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@bite_case_id", _biteCaseId);

            using var reader = command.ExecuteReader();
            if (!reader.Read())
                return new ProphylaxisHistoryData();

            return new ProphylaxisHistoryData
            {
                DateGiven = reader["date_given"] != DBNull.Value ? Convert.ToDateTime(reader["date_given"]) : null,
                VaccineBrand = reader["vaccine_brand"]?.ToString() ?? string.Empty,
                Route = reader["route"]?.ToString() ?? string.Empty,
                IsHrigGiven = reader["is_hrig_given"] != DBNull.Value && Convert.ToBoolean(reader["is_hrig_given"]),
                IsBooster = reader["is_booster"] != DBNull.Value && Convert.ToBoolean(reader["is_booster"]),
                PepCompletedDate = reader["pep_completed_date"] != DBNull.Value ? Convert.ToDateTime(reader["pep_completed_date"]) : null,
                ConsentNotes = reader["consent_notes"]?.ToString() ?? string.Empty
            };
        }

        private List<TreatmentScheduleData> LoadTreatmentSchedules()
        {
            var schedules = new List<TreatmentScheduleData>();

            using var connection = _connectionHelper.GetConnection();
            connection.Open();

            const string sql = @"
SELECT
    treatment_schedule_id,
    bite_case_id,
    schedule_day,
    scheduled_date,
    administered_date,
    biologic_type,
    item_id,
    generic_name,
    brand_name,
    item_name,
    category,
    strength,
    dosage_form,
    unit,
    quantity_used,
    status,
    administered_by,
    remarks,
    route,
    created_at
FROM v_treatment_schedule
WHERE bite_case_id = @bite_case_id
ORDER BY
    FIELD(schedule_day, 'Day 0', 'Day 3', 'Day 7', 'Day 14', 'Day 28', 'Booster'),
    scheduled_date;";

            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@bite_case_id", _biteCaseId);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                schedules.Add(new TreatmentScheduleData
                {
                    TreatmentScheduleId = reader["treatment_schedule_id"] != DBNull.Value ? Convert.ToInt32(reader["treatment_schedule_id"]) : 0,
                    BiteCaseId = reader["bite_case_id"] != DBNull.Value ? Convert.ToInt32(reader["bite_case_id"]) : 0,
                    ScheduleDay = reader["schedule_day"]?.ToString() ?? string.Empty,
                    ScheduledDate = reader["scheduled_date"] != DBNull.Value ? Convert.ToDateTime(reader["scheduled_date"]) : (DateTime?)null,
                    AdministeredDate = reader["administered_date"] != DBNull.Value ? Convert.ToDateTime(reader["administered_date"]) : (DateTime?)null,
                    BiologicType = reader["biologic_type"]?.ToString() ?? string.Empty,
                    ItemId = reader["item_id"]?.ToString() ?? string.Empty,
                    GenericName = reader["generic_name"]?.ToString() ?? string.Empty,
                    BrandName = reader["brand_name"]?.ToString() ?? string.Empty,
                    ItemName = reader["item_name"]?.ToString() ?? string.Empty,
                    Category = reader["category"]?.ToString() ?? string.Empty,
                    Strength = reader["strength"]?.ToString() ?? string.Empty,
                    DosageForm = reader["dosage_form"]?.ToString() ?? string.Empty,
                    Unit = reader["unit"]?.ToString() ?? string.Empty,
                    QuantityUsed = reader["quantity_used"] != DBNull.Value ? Convert.ToDecimal(reader["quantity_used"]) : (decimal?)null,
                    Status = reader["status"]?.ToString() ?? string.Empty,
                    AdministeredBy = reader["administered_by"]?.ToString() ?? string.Empty,
                    Remarks = reader["remarks"]?.ToString() ?? string.Empty,
                    Route = reader["route"]?.ToString() ?? string.Empty
                });
            }

            return schedules;
        }

        private List<CategoryBasisData> LoadCategoryBasis()
        {
            var basisList = new List<CategoryBasisData>();

            using var connection = _connectionHelper.GetConnection();
            connection.Open();

            const string sql = @"
SELECT
    cbm.basis_id,
    cbm.exposure_category,
    cbm.basis_description,
    CASE WHEN bccb.exposure_category_id IS NOT NULL THEN 1 ELSE 0 END AS is_selected
FROM category_basis_master cbm
LEFT JOIN bite_case_category_basis bccb
    ON cbm.basis_id = bccb.exposure_category_id
   AND bccb.bite_case_id = @bite_case_id
ORDER BY cbm.exposure_category, cbm.basis_id;";

            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@bite_case_id", _biteCaseId);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                basisList.Add(new CategoryBasisData
                {
                    BasisId = reader["basis_id"] != DBNull.Value ? Convert.ToInt32(reader["basis_id"]) : 0,
                    Category = reader["exposure_category"]?.ToString()?.Trim()?.ToUpperInvariant() ?? string.Empty,
                    Description = reader["basis_description"]?.ToString() ?? string.Empty,
                    IsSelected = reader["is_selected"] != DBNull.Value && Convert.ToInt32(reader["is_selected"]) == 1
                });
            }

            return basisList;
        }

        private Image? LoadPatientImage()
        {
            if (_patientData?.ImageBytes == null || _patientData.ImageBytes.Length == 0)
                return null;

            try
            {
                using var ms = new MemoryStream(_patientData.ImageBytes);
                using var img = Image.FromStream(ms);
                return new Bitmap(img);
            }
            catch
            {
                return null;
            }
        }

        private Image? LoadBiteChartImage()
        {
            if (string.IsNullOrWhiteSpace(_biteCaseData?.BiteChartPath) || !File.Exists(_biteCaseData.BiteChartPath))
                return null;

            try
            {
                using var fs = new FileStream(_biteCaseData.BiteChartPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                using var img = Image.FromStream(fs);
                return new Bitmap(img);
            }
            catch
            {
                return null;
            }
        }

        private Image? LoadLogoImage()
        {
            string logoPath = @"C:\Users\wenwe\source\repos\ABMS-2026\Resources\Images\shoot-animalbitelogo.png";
            
            if (!File.Exists(logoPath))
                return null;

            try
            {
                using var fs = new FileStream(logoPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                using var img = Image.FromStream(fs);
                return new Bitmap(img);
            }
            catch
            {
                return null;
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            float x = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;
            float width = e.MarginBounds.Width;

            if (_currentPage == 0)
            {
                if (e.Graphics != null)
                {
                    PrintPage1(e.Graphics, x, y, width, e);
                }
                _currentPage = 1;
                e.HasMorePages = true;
                return;
            }

            if (_currentPage == 1)
            {
                if (e.Graphics != null)
                {
                    PrintPage2(e.Graphics, x, y, width, e);
                }
                _currentPage = 2;
                e.HasMorePages = false;
            }
        }

        private void PrintPage1(Graphics g, float x, float y, float width, PrintPageEventArgs e)
        {
            float currentY = y;

            currentY = PrintHeader(g, x, currentY, width);
            currentY = PrintPatientProfile(g, x, currentY, width);
            currentY = PrintExposureHistory(g, x, currentY, width);

            currentY = PrintCategoryBasisHorizontal(g, x + 8, currentY, width - 16);

            currentY = PrintDoctorOrder(g, x, currentY, width);

            // Print footer at the bottom of the page
            PrintFooter(g, x, e.MarginBounds.Bottom - 20, width, 1, _totalPages);
        }

        private void PrintPage2(Graphics g, float x, float y, float width, PrintPageEventArgs e)
        {
            float currentY = y;

            currentY = PrintProphylaxisSection(g, x, currentY, width);
            currentY = PrintVaccinationSchedule(g, x, currentY, width);

            // Print footer at the bottom of the page
            PrintFooter(g, x, e.MarginBounds.Bottom - 20, width, 2, _totalPages);
        }

        private float PrintHeader(Graphics g, float x, float y, float width)
        {
            int h = 60;
            DrawFilledRect(g, _headerBackColor, _headerBorderColor, x, y, width, h);

            string title = "SHOT ANIMAL BITE CENTER";
            string subtitle = "INDIVIDUAL PATIENT'S RECORD";

            if (_logoImage != null)
            {
                int logoWidth = 80;
                int logoHeight = 50;
                Rectangle logoRect = new Rectangle((int)x + 10, (int)y + 5, logoWidth, logoHeight);

                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

                g.DrawImage(_logoImage, logoRect);
            }

            using var white = new SolidBrush(Color.White);
            using var center = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            // True center of the full header bar
            g.DrawString(title, _headerFont, white, new RectangleF(x, y + 5, width, 22), center);
            g.DrawString(subtitle, _subHeaderFont, white, new RectangleF(x, y + 27, width, 18), center);

            return y + h + 8;
        }

        private void PrintFooter(Graphics g, float x, float y, float width, int currentPage, int totalPages)
        {
            string pageText = $"Page {currentPage} of {totalPages}";
            
            SizeF textSize = g.MeasureString(pageText, _normalFont);
            float textX = x + (width - textSize.Width) / 2;
            
            using var brush = new SolidBrush(Color.Black);
            g.DrawString(pageText, _normalFont, brush, textX, y);
        }

        private float PrintPatientProfile(Graphics g, float x, float y, float width)
        {
            int h = 145;
            DrawSectionHeader(g, x, y, width, "PATIENT'S PROFILE");

            float contentY = y + 28;
            float leftX = x + 8;
            float photoX = x + width - 120;

            //==========================
            // Patient Photo
            //==========================
            Rectangle photoRect = new Rectangle((int)photoX, (int)contentY, 120, 120);
            g.DrawRectangle(Pens.Black, photoRect);

            if (_patientImage != null)
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

                g.DrawImage(_patientImage, photoRect);
            }

            float fieldY = contentY + 10;

            //====================================================
            // ROW 1
            //====================================================
            DrawUnderlinedField(
                g,
                leftX,
                fieldY,
                90,
                340,
                "Patient Name",
                $"{_patientData.LastName}, {_patientData.FirstName} {_patientData.MiddleName}".Trim());

            fieldY += 30;

            //====================================================
            // ROW 2
            //====================================================
            DrawUnderlinedField(
                g,
                leftX,
                fieldY,
                60,
                250,
                "Address",
                _patientData.Address);

            fieldY += 30;

            //====================================================
            // ROW 3
            //====================================================
            DrawUnderlinedField(
                g,
                leftX,
                fieldY,
                55,
                120,
                "Birthday",
                _patientData.BirthDate?.ToString("MM/dd/yyyy") ?? "");

            DrawUnderlinedField(
                g,
                leftX + 190,
                fieldY,
                30,
                40,
                "Age",
                _patientData.Age?.ToString() ?? "");

            DrawUnderlinedField(
                g,
                leftX + 280,
                fieldY,
                30,
                35,
                "Sex",
                _patientData.Sex);

 
            fieldY += 30;

            //====================================================
            // ROW 4
            //====================================================
            DrawUnderlinedField(
                g,
                leftX,
                fieldY,
                65,
                170,
                "Contact No.",
                _patientData.ContactNo);

            DrawUnderlinedField(
                g,
                leftX + 270,
                fieldY,
                55,
                120,
                "Reg. No.",
                _patientData.RegistrationNo);

            return y + h + 6;
        }

        private float PrintExposureHistory(Graphics g, float x, float y, float width)
        {
            int h = 280;
            DrawSectionHeader(g, x, y, width, "EXPOSURE HISTORY");

            float padding = 8f;
            float topY = y + 28;
            float gap = 12f;

            //==========================
            // 30% Details | 70% Image
            //==========================
            float leftWidth = width * 0.40f;
            float rightWidth = width - leftWidth - (padding * 2) - gap;

            float leftX = x + padding;
            float rightX = leftX + leftWidth + gap;

            //==========================
            // LEFT COLUMN
            //==========================
            float rowY = topY + 20;
            const float rowSpacing = 22f;

            DrawUnderlinedField(g, leftX, rowY, 120, leftWidth - 115,
                "Date of Exposure",
                _biteCaseData.ExposureDate?.ToString("MM/dd/yyyy") ?? "");
            rowY += rowSpacing;

            DrawUnderlinedField(g, leftX, rowY, 120, leftWidth - 115,
                "Place of Occurrence",
                _biteCaseData.IncidentPlace);
            rowY += rowSpacing;

            DrawUnderlinedField(g, leftX, rowY, 120, leftWidth - 115,
                "Type of Animal",
                _biteCaseData.AnimalType);
            rowY += rowSpacing;

            DrawUnderlinedField(g, leftX, rowY, 120, leftWidth - 115,
                "Animal Classification",
                _biteCaseData.AnimalClassification);
            rowY += rowSpacing;

            DrawUnderlinedField(g, leftX, rowY, 120, leftWidth - 115,
                "Animal Status",
                _biteCaseData.AnimalStatus);
            rowY += rowSpacing;

            DrawUnderlinedField(g, leftX, rowY, 120, leftWidth - 115,
                "Wound Type",
                _biteCaseData.WoundType);
            rowY += rowSpacing;

            DrawUnderlinedField(g, leftX, rowY, 120, leftWidth - 115,
                "Wound Count",
                _biteCaseData.WoundCount);
            rowY += rowSpacing;

            DrawUnderlinedField(g, leftX, rowY, 120, leftWidth - 115,
                "Wound Classification",
                _biteCaseData.WoundClassification);
            rowY += 24;

            // Wound Washed (checkbox on the right)
            g.DrawString("Wound Washed", _normalFont, Brushes.Black, leftX, rowY);

            float checkSize = 12;
            float checkX = leftX + leftWidth - 150;

            Rectangle checkRect = new Rectangle(
                (int)checkX,
                (int)(rowY + 2),
                (int)checkSize,
                (int)checkSize);

            g.DrawRectangle(Pens.Black, checkRect);

            if (_biteCaseData.IsWoundWashed)
            {
                g.DrawLine(Pens.Black,
                    checkRect.Left + 2,
                    checkRect.Top + 6,
                    checkRect.Left + 5,
                    checkRect.Bottom - 2);

                g.DrawLine(Pens.Black,
                    checkRect.Left + 5,
                    checkRect.Bottom - 2,
                    checkRect.Right - 2,
                    checkRect.Top + 2);
            }

            //==========================
            // RIGHT COLUMN - LARGE IMAGE
            //==========================
            Rectangle chartRect = new Rectangle(
                (int)rightX,
                (int)topY,
                (int)rightWidth,
                245);

            g.DrawRectangle(Pens.Black, chartRect);

            if (_biteChartImage != null)
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

                g.DrawImage(_biteChartImage, chartRect);
            }

            return y + h + 6;
        }
        private float PrintCategoryBasisHorizontal(Graphics g, float x, float y, float width)
        {
            float gap = 12f;

            // Layout: Left column = Category I & II, Right column = Category III
            float leftWidth = width * 0.42f;
            float rightWidth = width - leftWidth - gap;

            float leftX = x;
            float rightX = leftX + leftWidth + gap;

            //==========================
            // LEFT COLUMN
            //==========================

            float leftY = y;

            // CATEGORY I
            g.DrawString("CATEGORY I", _boldFont, Brushes.Black, leftX, leftY);
            leftY += 16;

            foreach (var item in _categoryBasisList.Where(c =>
                c.Category == "I" || c.Category == "CATEGORY I"))
            {
                float itemHeight = DrawCheckboxTextWrapped(
                    g,
                    leftX,
                    leftY,
                    item.Description,
                    item.IsSelected,
                    leftWidth);

                leftY += itemHeight + 4;
            }

            leftY += 10;

            // CATEGORY II
            g.DrawString("CATEGORY II", _boldFont, Brushes.Black, leftX, leftY);
            leftY += 16;

            foreach (var item in _categoryBasisList.Where(c =>
                c.Category == "II" || c.Category == "CATEGORY II"))
            {
                float itemHeight = DrawCheckboxTextWrapped(
                    g,
                    leftX,
                    leftY,
                    item.Description,
                    item.IsSelected,
                    leftWidth);

                leftY += itemHeight + 4;
            }

            //==========================
            // RIGHT COLUMN
            //==========================

            float rightY = y;

            g.DrawString("CATEGORY III", _boldFont, Brushes.Black, rightX, rightY);
            rightY += 16;

            foreach (var item in _categoryBasisList.Where(c =>
                c.Category == "III" || c.Category == "CATEGORY III"))
            {
                float itemHeight = DrawCheckboxTextWrapped(
                    g,
                    rightX,
                    rightY,
                    item.Description,
                    item.IsSelected,
                    rightWidth);

                rightY += itemHeight + 4;
            }

            // Return the tallest column
            return Math.Max(leftY, rightY) + 8;
        }

        private float DrawCheckboxTextWrapped(
            Graphics g,
            float x,
            float y,
            string text,
            bool isChecked,
            float width)
        {
            const float checkSize = 10f;
            const float checkGap = 5f;

            // Draw checkbox
            RectangleF checkBox = new RectangleF(x, y + 2, checkSize, checkSize);
            g.DrawRectangle(Pens.Black, checkBox.X, checkBox.Y, checkBox.Width, checkBox.Height);

            if (isChecked)
            {
                g.DrawLine(Pens.Black,
                    checkBox.Left + 2,
                    checkBox.Top + 6,
                    checkBox.Left + 4,
                    checkBox.Bottom - 2);

                g.DrawLine(Pens.Black,
                    checkBox.Left + 4,
                    checkBox.Bottom - 2,
                    checkBox.Right - 2,
                    checkBox.Top + 2);
            }

            // Text area
            float textX = x + checkSize + checkGap;
            float textWidth = width - checkSize - checkGap;

            StringFormat sf = new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Near,
                Trimming = StringTrimming.Word,
                FormatFlags = StringFormatFlags.LineLimit
            };

            SizeF measured = g.MeasureString(
                text,
                _smallFont,
                new SizeF(textWidth, 1000),
                sf);

            RectangleF textRect = new RectangleF(
                textX,
                y,
                textWidth,
                measured.Height);

            g.DrawString(
                text,
                _smallFont,
                Brushes.Black,
                textRect,
                sf);

            return Math.Max(checkSize, measured.Height);
        }

        private float PrintDoctorOrder(Graphics g, float x, float y, float width)
        {
            const int sectionHeight = 300;

            DrawSectionHeader(g, x, y, width, "DOCTOR'S ORDER");

            float margin = 8f;
            float topY = y + 28;

            float leftWidth = width * 0.52f;
            float rightWidth = width - leftWidth - (margin * 2);

            float leftX = x + margin;
            float rightX = leftX + leftWidth + margin;

            //=====================================================
            // LEFT SIDE
            //=====================================================

            DrawWrappedField(
                g,
                leftX,
                topY,
                leftWidth - 10,
                "HISTORY OF PRESENT ILLNESS",
                _doctorOrderData.HistoryPresentIllness,
                34);

            DrawWrappedField(
                g,
                leftX,
                topY + 42,
                leftWidth - 10,
                "PERTINENT PHYSICAL EXAMINATION",
                _doctorOrderData.PhysicalExamination,
                34);

            DrawWrappedField(
                g,
                leftX,
                topY + 84,
                leftWidth - 10,
                "DIAGNOSIS",
                _doctorOrderData.Diagnosis,
                28);

            DrawWrappedField(
                g,
                leftX,
                topY + 120,
                leftWidth - 10,
                "MANAGEMENT",
                _doctorOrderData.Management,
                44);

            //-----------------------------------------------------
            // Treatments
            //-----------------------------------------------------

            float treatY = topY + 190;

            DrawCheckboxLine(g, leftX + 5, treatY, "PEP", _doctorOrderData.IsPep);

            DrawCheckboxLine(g, leftX + 75, treatY, "PREP", _doctorOrderData.IsPrep);
            DrawUnderlinedField(g, leftX + 120, treatY, 0, 70, "", _doctorOrderData.PrepDetails);

            treatY += 24;

            DrawCheckboxLine(g, leftX + 5, treatY, "ERIG", _doctorOrderData.IsErig);
            DrawUnderlinedField(g, leftX + 55, treatY, 0, 110, "", _doctorOrderData.ErigDetails);

            treatY += 24;

            DrawCheckboxLine(g, leftX + 5, treatY, "TETANUS DIPHTHERIA", _doctorOrderData.IsTetanusDiphtheria);

            DrawCheckboxLine(g, leftX + 150, treatY, "TETANUS TOXOID", _doctorOrderData.IsTetanusToxoid);
            DrawUnderlinedField(g, leftX + 280, treatY, 0, 70, "", _doctorOrderData.TetanusToxoidDetails);

            treatY += 24;

            DrawCheckboxLine(g, leftX + 5, treatY, "ANTITETANUS SERUM", _doctorOrderData.IsAntiTetanusSerum);
            DrawUnderlinedField(g, leftX + 165, treatY, 0, 120, "", _doctorOrderData.AntiTetanusSerumDetails);


            //=====================================================
            // RIGHT SIDE
            //=====================================================

            DrawWrappedField(
                g,
                rightX,
                topY,
                rightWidth,
                "OTHER MANAGEMENT",
                _doctorOrderData.OtherManagement,
                34);

            g.DrawString(
                "MEDICATIONS:",
                _normalFont,
                Brushes.Black,
                rightX,
                topY + 52);

            float medY = topY + 78;

            DrawCheckboxLine(g, rightX + 25, medY, "ANTIBIOTIC", !string.IsNullOrEmpty(_doctorOrderData.MedicationAntibiotic));
            DrawUnderlinedField(g,
                rightX + 135,
                medY,
                0,
                rightWidth - 150,
                "",
                _doctorOrderData.MedicationAntibiotic);

            medY += 24;

            DrawCheckboxLine(g, rightX + 25, medY, "NSAID", !string.IsNullOrEmpty(_doctorOrderData.MedicationNsaid));
            DrawUnderlinedField(g,
                rightX + 135,
                medY,
                0,
                rightWidth - 150,
                "",
                _doctorOrderData.MedicationNsaid);

            medY += 24;

            DrawCheckboxLine(g, rightX + 25, medY, "OTHERS", !string.IsNullOrEmpty(_doctorOrderData.MedicationOthers));
            DrawUnderlinedField(g,
                rightX + 135,
                medY,
                0,
                rightWidth - 150,
                "",
                _doctorOrderData.MedicationOthers);

            //=====================================================
            // PHYSICIAN
            //=====================================================

            float doctorY = y + sectionHeight + 20;

            using (Font doctorFont = new Font("Arial", 9, FontStyle.Bold))
            using (StringFormat sf = new StringFormat()
            {
                Alignment = StringAlignment.Center
            })
            {
                g.DrawString(
                    string.IsNullOrWhiteSpace(_doctorOrderData.DoctorName)
                        ? "JOEBERT M. VILLANUEVA, MD, FPSO-HNS"
                        : _doctorOrderData.DoctorName,
                    doctorFont,
                    Brushes.Black,
                    new RectangleF(rightX, doctorY, rightWidth, 20),
                    sf);

                g.DrawString(
                    "ATTENDING PHYSICIAN",
                    _normalFont,
                    Brushes.Black,
                    new RectangleF(rightX, doctorY + 22, rightWidth, 20),
                    sf);
            }

            return y + sectionHeight + 6;
        }

        private float PrintPatientInfoStrip(Graphics g, float x, float y, float width)
        {
            int h = 48;
            g.DrawRectangle(Pens.Black, (int)x, (int)y, (int)width, h);

            if (_patientImage != null)
            {
                Rectangle photoRect = new Rectangle((int)x + 6, (int)y + 4, 40, 40);
                g.DrawRectangle(Pens.Black, photoRect);
                
                // High quality small photo rendering
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                
                g.DrawImage(_patientImage, photoRect);
            }

            string name = $"{_patientData.LastName}, {_patientData.FirstName} {_patientData.MiddleName}".Trim();
            g.DrawString(name, _boldFont, Brushes.Black, x + 52, y + 8);
            g.DrawString($"REG NO. {_patientData.RegistrationNo}", _normalFont, Brushes.Black, x + 52, y + 24);

            return y + h + 6;
        }

        private float PrintProphylaxisSection(Graphics g, float x, float y, float width)
        {
            int h = 175;

            DrawSectionHeader(g, x, y, width, "PRE / POST EXPOSURE PROPHYLAXIS");

            float padding = 8f;
            float topY = y + 30;

            float gap = 20f;

            float columnWidth = (width - (padding * 2) - gap) / 2;

            float leftX = x + padding;
            float rightX = leftX + columnWidth + gap;

            float row = topY;
            const float rowHeight = 22f;

            //=========================================
            // LEFT COLUMN
            //=========================================

            DrawUnderlinedField(g, leftX, row, 60, 70,
                "Weight",
                _patientData.Weight?.ToString("0.##") ?? "");

            DrawCheckboxLine(g, leftX + 145, row, "PEP", _doctorOrderData.IsPep);
            DrawCheckboxLine(g, leftX + 195, row, "PREP", _doctorOrderData.IsPrep);
            DrawCheckboxLine(g, leftX + 255, row, "Booster", _prophylaxisHistoryData.IsBooster);

            row += rowHeight;

            DrawCheckboxLine(g, leftX, row, "ERIG", _doctorOrderData.IsErig);
            DrawUnderlinedField(g,
                leftX + 50,
                row,
                0,
                120,
                "",
                _doctorOrderData.ErigDetails);

            row += rowHeight;

            DrawCheckboxLine(g, leftX, row, "HRIG", _doctorOrderData.IsHrig);
            DrawUnderlinedField(g,
                leftX + 50,
                row,
                0,
                120,
                "",
                _doctorOrderData.HrigDetails);

            row += rowHeight;

            DrawCheckboxLine(g, leftX, row,
                "Tetanus Toxoid",
                _doctorOrderData.IsTetanusToxoid);

            DrawUnderlinedField(g,
                leftX + 120,
                row,
                0,
                120,
                "",
                _doctorOrderData.TetanusToxoidDetails);

            row += rowHeight;

            DrawCheckboxLine(g, leftX, row,
                "ATS",
                _doctorOrderData.IsAntiTetanusSerum);

            DrawUnderlinedField(g,
                leftX + 50,
                row,
                0,
                120,
                "",
                _doctorOrderData.AntiTetanusSerumDetails);

            row += rowHeight;

            DrawCheckboxLine(g,
                leftX,
                row,
                "Anti-Rabies Vaccine",
                true);

            //=========================================
            // RIGHT COLUMN
            //=========================================

            float rightRow = topY;

            DrawUnderlinedField(g,
                rightX,
                rightRow,
                70,
                220,
                "Brand",
                _prophylaxisHistoryData.VaccineBrand);

            rightRow += rowHeight;

            DrawUnderlinedField(g,
                rightX,
                rightRow,
                70,
                220,
                "Route",
                _prophylaxisHistoryData.Route);

            rightRow += rowHeight;

            DrawUnderlinedField(g,
                rightX,
                rightRow,
                125,
                165,
                "PEP Completed",
                _prophylaxisHistoryData.PepCompletedDate?.ToString("MM/dd/yyyy") ?? "");

            return y + h + 6;
        }

        private float PrintVaccinationSchedule(Graphics g, float x, float y, float width)
        {
            int h = 240;
            float rowHeight = 42;
            float scheduleCol = 65;
            float routeCol = 70;
            float dateCol = 80;
            float signatureCol = 100;
            float vaccineCol = width - scheduleCol - routeCol - dateCol - signatureCol - 30;

            g.DrawRectangle(Pens.Black, (int)x, (int)y, (int)width, h);
            g.DrawLine(Pens.Black, x, y + 22, x + width, y + 22);
            g.DrawLine(Pens.Black, x + scheduleCol, y, x + scheduleCol, y + h);
            g.DrawLine(Pens.Black, x + scheduleCol + vaccineCol, y, x + scheduleCol + vaccineCol, y + h);
            g.DrawLine(Pens.Black, x + scheduleCol + vaccineCol + routeCol, y, x + scheduleCol + vaccineCol + routeCol, y + h);
            g.DrawLine(Pens.Black, x + scheduleCol + vaccineCol + routeCol + dateCol, y, x + scheduleCol + vaccineCol + routeCol + dateCol, y + h);

            g.DrawString("SCHEDULE OF VACCINATION", _boldFont, Brushes.Black, x + 2, y - 12);

            g.DrawString("DAY", _boldFont, Brushes.Black, x + 6, y + 4);
            g.DrawString("VACCINE", _boldFont, Brushes.Black, x + scheduleCol + 6, y + 4);
            g.DrawString("ROUTE", _boldFont, Brushes.Black, x + scheduleCol + vaccineCol + 6, y + 4);
            g.DrawString("DATE", _boldFont, Brushes.Black, x + scheduleCol + vaccineCol + routeCol + 6, y + 4);
            g.DrawString("NAME / SIGNATURE", _boldFont, Brushes.Black, x + scheduleCol + vaccineCol + routeCol + dateCol + 6, y + 4);

            string[] days = { "Day 0", "Day 3", "Day 7", "Day 14/21", "Day 28/30" };

            for (int i = 0; i < days.Length; i++)
            {
                float rowY = y + 22 + (i * rowHeight);
                g.DrawLine(Pens.Black, x, rowY, x + width, rowY);

                g.DrawString(days[i], _boldFont, Brushes.Black, x + 8, rowY + 12);

                var match = _treatmentSchedules.FirstOrDefault(t =>
                    string.Equals(t.ScheduleDay, days[i], StringComparison.OrdinalIgnoreCase) ||
                    (days[i] == "Day 14/21" && (t.ScheduleDay == "Day 14")) ||
                    (days[i] == "Day 28/30" && (t.ScheduleDay == "Day 28")));

                if (match != null)
                {
                    // Concatenate item name with details
                    string itemName = match.ItemName ?? string.Empty;
                    if (!string.IsNullOrEmpty(match.BrandName) && !string.IsNullOrEmpty(match.GenericName))
                    {
                        itemName = $"{match.BrandName} ({match.GenericName})";
                    }
                    else if (!string.IsNullOrEmpty(match.BrandName))
                    {
                        itemName = match.BrandName;
                    }
                    else if (!string.IsNullOrEmpty(match.GenericName))
                    {
                        itemName = match.GenericName;
                    }

                    g.DrawString(itemName, _normalFont, Brushes.Black, x + scheduleCol + 6, rowY + 12);
                    g.DrawString(match.Route ?? string.Empty, _normalFont, Brushes.Black, x + scheduleCol + vaccineCol + 6, rowY + 12);
                    g.DrawString(match.AdministeredDate?.ToString("MM/dd/yyyy") ?? string.Empty, _normalFont, Brushes.Black, x + scheduleCol + vaccineCol + routeCol + 6, rowY + 12);
                    g.DrawString(match.AdministeredBy ?? string.Empty, _normalFont, Brushes.Black, x + scheduleCol + vaccineCol + routeCol + dateCol + 6, rowY + 12);
                }
            }

            return y + h + 6;
        }

        private void DrawSectionHeader(Graphics g, float x, float y, float width, string text)
        {
            int h = 20;
            DrawFilledRect(g, _sectionHeaderBackColor, _headerBorderColor, x, y, width, h);
            var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            g.DrawString(text, _sectionHeaderFont, Brushes.White, new RectangleF(x, y, width, h), sf);
        }

        private void DrawFilledRect(Graphics g, Color backColor, Color borderColor, float x, float y, float width, float height)
        {
            var rect = new Rectangle((int)x, (int)y, (int)width, (int)height);
            using var brush = new SolidBrush(backColor);
            using var pen = new Pen(borderColor, 1);
            g.FillRectangle(brush, rect);
            g.DrawRectangle(pen, rect);
        }

        private void DrawUnderlinedField(Graphics g, float x, float y, float labelWidth, float valueWidth, string label, string value)
        {
            g.DrawString(label, _normalFont, Brushes.Black, x, y);
            g.DrawLine(Pens.Black, x + labelWidth, y + 12, x + labelWidth + valueWidth, y + 12);
            if (!string.IsNullOrWhiteSpace(value))
                g.DrawString(value, _normalFont, Brushes.Black, x + labelWidth + 2, y - 1);
        }

        private void DrawWrappedField(Graphics g, float x, float y, float width, string label, string value, float boxHeight)
        {
            g.DrawString(label, _boldFont, Brushes.Black, x, y);

            var rect = new RectangleF(x, y + 10, width, boxHeight);

            if (string.IsNullOrWhiteSpace(value))
            {
                g.DrawLine(Pens.Black, x, y + 22, x + width, y + 22);
                return;
            }

            using var sf = new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Near,
                Trimming = StringTrimming.EllipsisWord,
                FormatFlags = StringFormatFlags.LineLimit
            };

            g.DrawString(value, _normalFont, Brushes.Black, rect, sf);
        }

        private void DrawCheckboxLine(Graphics g, float x, float y, string label, bool checkedState)
        {
            string mark = checkedState ? "☑" : "☐";
            g.DrawString(mark, _normalFont, Brushes.Black, x, y);
            g.DrawString(label, _normalFont, Brushes.Black, x + 12, y);
        }

        private void DrawCheckboxText(Graphics g, float x, float y, string text, bool checkedState, float width)
        {
            string mark = checkedState ? "☑" : "☐";
            g.DrawString(mark, _smallFont, Brushes.Black, x, y);
            g.DrawString(text, _smallFont, Brushes.Black, x + 10, y);
        }

        private class PatientData
        {
            public int PatientId { get; set; }
            public string RegistrationNo { get; set; } = string.Empty;
            public string LastName { get; set; } = string.Empty;
            public string FirstName { get; set; } = string.Empty;
            public string MiddleName { get; set; } = string.Empty;
            public DateTime? BirthDate { get; set; }
            public int? Age { get; set; }
            public string Sex { get; set; } = string.Empty;
            public string CivilStatus { get; set; } = string.Empty;
            public string Address { get; set; } = string.Empty;
            public string ContactNo { get; set; } = string.Empty;
            public decimal? Weight { get; set; }
            public byte[]? ImageBytes { get; set; }

            public string FullName =>
                string.IsNullOrWhiteSpace(MiddleName)
                    ? $"{LastName}, {FirstName}"
                    : $"{LastName}, {FirstName} {MiddleName}";
        }

        private class BiteCaseData
        {
            public DateTime? ExposureDate { get; set; }
            public string IncidentPlace { get; set; } = string.Empty;
            public string AnimalType { get; set; } = string.Empty;
            public string AnimalClassification { get; set; } = string.Empty;
            public string AnimalStatus { get; set; } = string.Empty;
            public bool IsWoundWashed { get; set; }
            public string WoundType { get; set; } = string.Empty;
            public string WoundCount { get; set; } = string.Empty;
            public string WoundClassification { get; set; } = string.Empty;
            public string BiteLocations { get; set; } = string.Empty;
            public string BiteChartPath { get; set; } = string.Empty;
            public string Remarks { get; set; } = string.Empty;
        }

        private class DoctorOrderData
        {
            public string HistoryPresentIllness { get; set; } = string.Empty;
            public string PhysicalExamination { get; set; } = string.Empty;
            public string Diagnosis { get; set; } = string.Empty;
            public string Management { get; set; } = string.Empty;
            public string OtherManagement { get; set; } = string.Empty;
            public string MedicationAntibiotic { get; set; } = string.Empty;
            public string MedicationNsaid { get; set; } = string.Empty;
            public string MedicationOthers { get; set; } = string.Empty;
            public bool IsPep { get; set; }
            public bool IsPrep { get; set; }
            public string PrepDetails { get; set; } = string.Empty;
            public bool IsErig { get; set; }
            public string ErigDetails { get; set; } = string.Empty;
            public bool IsHrig { get; set; }
            public string HrigDetails { get; set; } = string.Empty;
            public bool IsTetanusDiphtheria { get; set; }
            public bool IsTetanusToxoid { get; set; }
            public string TetanusToxoidDetails { get; set; } = string.Empty;
            public bool IsAntiTetanusSerum { get; set; }
            public string AntiTetanusSerumDetails { get; set; } = string.Empty;
            public string DoctorName { get; set; } = string.Empty;
        }

        private class ProphylaxisHistoryData
        {
            public DateTime? DateGiven { get; set; }
            public string VaccineBrand { get; set; } = string.Empty;
            public string Route { get; set; } = string.Empty;
            public bool IsHrigGiven { get; set; }
            public bool IsBooster { get; set; }
            public DateTime? PepCompletedDate { get; set; }
            public string ConsentNotes { get; set; } = string.Empty;
        }

        private class TreatmentScheduleData
        {
            public int TreatmentScheduleId { get; set; }
            public int BiteCaseId { get; set; }
            public string ScheduleDay { get; set; } = string.Empty;
            public DateTime? ScheduledDate { get; set; }
            public DateTime? AdministeredDate { get; set; }
            public string BiologicType { get; set; } = string.Empty;
            public string ItemId { get; set; } = string.Empty;
            public string GenericName { get; set; } = string.Empty;
            public string BrandName { get; set; } = string.Empty;
            public string ItemName { get; set; } = string.Empty;
            public string Category { get; set; } = string.Empty;
            public string Strength { get; set; } = string.Empty;
            public string DosageForm { get; set; } = string.Empty;
            public string Unit { get; set; } = string.Empty;
            public decimal? QuantityUsed { get; set; }
            public string Status { get; set; } = string.Empty;
            public string AdministeredBy { get; set; } = string.Empty;
            public string Remarks { get; set; } = string.Empty;
            public string Route { get; set; } = string.Empty;
        }

        private class CategoryBasisData
        {
            public int BasisId { get; set; }
            public string Category { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
            public bool IsSelected { get; set; }
        }
    }
}