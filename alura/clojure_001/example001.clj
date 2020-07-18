(println "Hello")

(def total-of-products 10)

(println "Total" total-of-products)

(def stock ["Bag", "T-Shirt"])

(println stock)

(println (conj stock "Shoes"))

(println stock)

(def stock (conj stock "Shoes"))

(println stock)

(defn discounted-value
  "Return the value subtracting 10% off discount",
  [value]
  (* value (- 1 0.1)))

(discounted-value 100)
