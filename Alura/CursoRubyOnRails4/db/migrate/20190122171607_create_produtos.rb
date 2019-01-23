class CreateProdutos < ActiveRecord::Migration[5.2]
  def change
    create_table :produtos do |t|
      t.string :nome
      t.text :descricao
      t.decimal :preco
      t.integer :quantidade

      t.timestamps
    end
  end
end
