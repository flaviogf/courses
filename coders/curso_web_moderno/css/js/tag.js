const colors = {
  p: "#388e3c",
  div: "#1565c0",
  span: "#e53935",
  section: "#f67809",
  ul: "#5e35b1",
  ol: "#fbc02d",
  header: "#d81b60",
  nav: "#64dd17",
  main: "#00acc1",
  footer: "#9f6581",
  body: "#25b6da",
  padrao: "#616161",
  get(tag) {
    return this[tag] || this["padrao"];
  }
};

document.querySelectorAll(".tag").forEach(el => {
  const tagName = el.tagName.toLowerCase();
  const color = colors.get(tagName);
  el.style.borderColor = color;

  if (el.classList.contains("nolabel")) return;

  const label = document.createElement("label");
  label.style.backgroundColor = color;
  label.innerText = tagName;
  el.insertBefore(label, el.childNodes[0]);
});
