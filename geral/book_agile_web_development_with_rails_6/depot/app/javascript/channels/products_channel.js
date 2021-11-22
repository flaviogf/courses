import consumer from "./consumer"

consumer.subscriptions.create("ProductsChannel", {
  connected() {
    // Called when the subscription is ready for use on the server
  },

  disconnected() {
    // Called when the subscription has been terminated by the server
  },

  received(data) {
    const storeElement = document.querySelector('main.store')
    if(!storeElement) return
    storeElement.innerHTML = data.html
  }
});
