(defn discounted-value
  "Return the value subtracting 10% off discount"
  [value]
  (let [discount (/ 10.0 100)]
    (* value (- 1 discount))))
