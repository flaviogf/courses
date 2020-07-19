(ns example007.core
  (:gen-class))

(defn subtotal [product]
  (* (:quantity product) (:price product)))

(defn -main
  [& args]
  (let [order {:backpack {:quantity 2, :price 80}
               :shirt    {:quantity 3, :price 40}}]
    (println order)
    (println (->> order
                  vals
                  (map subtotal)
                  (reduce +)))))
