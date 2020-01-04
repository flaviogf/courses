(() => {
    const qrcode = document.querySelector("[data-qrcode]");

    const key = document.querySelector("[data-key]").dataset.key;

    new QRCode(qrcode,
        {
            colorDark: "#ffffff",
            colorLight: "#000000",
            height: 280,
            text: key,
            width: 280,
        });
})();
