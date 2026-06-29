-- Create billing and billing_items tables for the ABMS-2026 application

-- Add unit_price column to inventory_items if it doesn't exist
ALTER TABLE `inventory_items` 
ADD COLUMN IF NOT EXISTS `unit_price` decimal(18,2) DEFAULT 0.00 AFTER `expiration_date`;

-- Create billing table
CREATE TABLE IF NOT EXISTS `billing` (
  `billing_id` int NOT NULL AUTO_INCREMENT,
  `bite_case_id` int NOT NULL,
  `billing_no` varchar(20) NOT NULL,
  `billing_date` date NOT NULL,
  `subtotal` decimal(18,2) NOT NULL DEFAULT 0.00,
  `discount` decimal(18,2) NOT NULL DEFAULT 0.00,
  `total` decimal(18,2) NOT NULL DEFAULT 0.00,
  `amount_paid` decimal(18,2) NOT NULL DEFAULT 0.00,
  `balance` decimal(18,2) NOT NULL DEFAULT 0.00,
  `payment_method` varchar(50) DEFAULT NULL,
  `payment_status` enum('Unpaid','Partial','Paid') DEFAULT 'Unpaid',
  `remarks` text,
  `created_at` datetime DEFAULT CURRENT_TIMESTAMP,
  `updated_at` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `created_by` varchar(100) DEFAULT NULL,
  `updated_by` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`billing_id`),
  UNIQUE KEY `uk_billing_no` (`billing_no`),
  KEY `fk_billing_bite_case` (`bite_case_id`),
  CONSTRAINT `fk_billing_bite_case` FOREIGN KEY (`bite_case_id`) REFERENCES `bite_cases` (`bite_case_id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Create billing_items table
CREATE TABLE IF NOT EXISTS `billing_items` (
  `billing_item_id` int NOT NULL AUTO_INCREMENT,
  `billing_id` int NOT NULL,
  `item_type` varchar(50) NOT NULL DEFAULT 'Service',
  `item_id` bigint DEFAULT NULL,
  `description` text NOT NULL,
  `quantity` int NOT NULL DEFAULT 1,
  `unit_price` decimal(18,2) NOT NULL DEFAULT 0.00,
  `line_total` decimal(18,2) NOT NULL DEFAULT 0.00,
  PRIMARY KEY (`billing_item_id`),
  KEY `fk_billing_item_billing` (`billing_id`),
  KEY `fk_billing_item_inventory` (`item_id`),
  CONSTRAINT `fk_billing_item_billing` FOREIGN KEY (`billing_id`) REFERENCES `billing` (`billing_id`) ON DELETE CASCADE,
  CONSTRAINT `fk_billing_item_inventory` FOREIGN KEY (`item_id`) REFERENCES `inventory_items` (`item_id`) ON DELETE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
