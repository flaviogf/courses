(ns example004.core
  (:gen-class))

(defn is-greater-than-100
  [value]
  (> value 100))

(defn discount
  [percent value]
  (* value (- 1 (/ percent 100.0))))

(def discount-of-10-percent (partial discount 10))

(def discount-of-50-percent (partial discount 50))

(defn discount
  [should-apply-discount? discount value]
  (if (should-apply-discount? value)
    (discount value)
    value))

(defn -main
  [& args]
  (println (discount is-greater-than-100 discount-of-10-percent 1000))
  (println (discount is-greater-than-100 discount-of-10-percent 100))
  (println (discount is-greater-than-100 discount-of-50-percent 1000))
  (println (discount is-greater-than-100 discount-of-50-percent 100))
  (println (discount #(> % 100) #(* % (- 1 0.3)) 1000))
  (println (discount #(> % 100) #(* % (- 1 0.3)) 100)))
