class AddApprovedToArticles < ActiveRecord::Migration[6.1]
  def change
    add_column :articles, :approved, :boolean
  end
end
