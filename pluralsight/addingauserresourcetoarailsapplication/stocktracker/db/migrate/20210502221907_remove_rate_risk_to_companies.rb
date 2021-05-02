class RemoveRateRiskToCompanies < ActiveRecord::Migration[6.1]
  def change
    remove_column :companies, :rate_risk
  end
end
