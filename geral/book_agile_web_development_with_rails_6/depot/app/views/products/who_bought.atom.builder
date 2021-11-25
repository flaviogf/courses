atom_feed do |feed|
  feed.title "Who bought #{@product.title}"
  feed.update @latest_order.try(:updated_at)

  @product.orders.each do |order|
    feed.entry(order) do |entry|
      entry.title = "Order #{order.id}"
    end
  end
end
