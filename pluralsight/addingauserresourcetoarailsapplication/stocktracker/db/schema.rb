# This file is auto-generated from the current state of the database. Instead
# of editing this file, please use the migrations feature of Active Record to
# incrementally modify your database, and then regenerate this schema definition.
#
# This file is the source Rails uses to define your schema when running `bin/rails
# db:schema:load`. When creating a new database, `bin/rails db:schema:load` tends to
# be faster and is potentially less error prone than running all of your
# migrations from scratch. Old migrations may fail to apply correctly if those
# migrations use external dependencies or application code.
#
# It's strongly recommended that you check this file into your version control system.

ActiveRecord::Schema.define(version: 2021_05_02_223438) do

  create_table "companies", force: :cascade do |t|
    t.string "name"
    t.string "ticker_symbol"
    t.datetime "created_at", precision: 6, null: false
    t.datetime "updated_at", precision: 6, null: false
    t.string "risk_factor"
  end

  create_table "cryptocurrencies", force: :cascade do |t|
    t.string "name"
    t.string "ticker_symbol"
    t.datetime "created_at", precision: 6, null: false
    t.datetime "updated_at", precision: 6, null: false
  end

  create_table "cryptocurrency_prices", force: :cascade do |t|
    t.decimal "price"
    t.datetime "captured_at"
    t.integer "cryptocurrency_id", null: false
    t.datetime "created_at", precision: 6, null: false
    t.datetime "updated_at", precision: 6, null: false
    t.index ["cryptocurrency_id"], name: "index_cryptocurrency_prices_on_cryptocurrency_id"
  end

  create_table "stock_prices", force: :cascade do |t|
    t.decimal "price"
    t.datetime "captured_at"
    t.integer "company_id", null: false
    t.datetime "created_at", precision: 6, null: false
    t.datetime "updated_at", precision: 6, null: false
    t.index ["company_id"], name: "index_stock_prices_on_company_id"
  end

  add_foreign_key "cryptocurrency_prices", "cryptocurrencies"
  add_foreign_key "stock_prices", "companies"
end
