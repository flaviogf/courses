(ns example005.core
  (:gen-class))

(def prices [10, 20, 30])

(defn discount
  [predicate? strategy value]
  (if (predicate? value)
    (strategy value)
    value))

(defn is-value-greater-than-15
  [value]
  (> value 15))

(defn discounted-value-of-10-percent
  [value]
  (* value (- 1 0.10)))

(defn -main
  [& args]
  (println (get prices 0))
  (println (get prices 10 0))
  (println (discount is-value-greater-than-15 discounted-value-of-10-percent 100))
  (println (map discounted-value-of-10-percent prices))
  (println (map discounted-value-of-10-percent (filter is-value-greater-than-15 prices))))
