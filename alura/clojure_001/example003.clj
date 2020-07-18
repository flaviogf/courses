(defn discount
 [tax value]
 (* value (- 1 (/ tax 100.0))))

(def discount-of-10-percent
  (partial discount 10))

(def discount-of-50-percent
  (partial discount 50))

(defn discount-for-values-greater-than-100
  [value, strategy]
  (if (> value 100)
    (strategy value)
    value))

(discount-for-values-greater-than-100 1000.0 discount-of-10-percent)

(discount-for-values-greater-than-100 100.0 discount-of-10-percent)

(discount-for-values-greater-than-100 1000.0 discount-of-50-percent)

(discount-for-values-greater-than-100 100.0 discount-of-50-percent)
