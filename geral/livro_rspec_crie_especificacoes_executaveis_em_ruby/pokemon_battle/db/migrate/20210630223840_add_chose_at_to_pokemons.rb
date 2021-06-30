class AddChoseAtToPokemons < ActiveRecord::Migration[6.1]
  def change
    add_column :pokemons, :chose_at, :datetime
  end
end
