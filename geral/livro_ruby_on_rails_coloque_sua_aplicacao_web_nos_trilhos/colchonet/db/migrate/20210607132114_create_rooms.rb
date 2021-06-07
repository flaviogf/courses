class CreateRooms < ActiveRecord::Migration[6.1]
  def change
    create_table :rooms do |t|
      t.string :title
      t.string :location
      t.text :description

      t.timestamps
    end
  end
end
