# frozen_string_literal: true

module Ex2
  PurchaseRecord = Struct.new(:email_address, :product_id)

  Customer = Struct.new(:email_address) do
    def add_purchased_product(product)
    end

    def notify_of_files_available(product)
    end
  end

  Product = Struct.new(:product_id)

  class LegacyDataParser
    def parse_purchase_records(data)
      data.collect { |it| PurchaseRecord.new(it[1], it[2]) }
    end
  end

  class CustomerList
    def get_customer(email_address)
      Customer.new(email_address)
    end
  end

  class ProductInventory
    def get_product(product_id)
      Product.new(product_id)
    end
  end

  class Logger
    def log(entry)
      puts entry.inspect
    end
  end

  class << self
    def import_legacy_purchase_data(data)
      purchase_list = legacy_data_parser.parse_purchase_records(data)
      purchase_list.each do |purchase_record|
        customer = customer_list.get_customer(purchase_record.email_address)
        product = product_inventory.get_product(purchase_record.product_id)
        customer.add_purchased_product(product)
        customer.notify_of_files_available(product)
        log_successful_import(purchase_record)
      end
    end

    def log_successful_import(purchase_record)
      logger.log(purchase_record)
    end

    def legacy_data_parser
      @legacy_data_parser ||= LegacyDataParser.new
    end

    def customer_list
      @customer_list ||= CustomerList.new
    end

    def product_inventory
      @product_inventory = ProductInventory.new
    end

    def logger
      @logger ||= Logger.new
    end
  end
end
