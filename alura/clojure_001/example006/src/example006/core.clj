(ns example006.core
  (:gen-class))

(defn -main
  [& args]
  (let [storage {"Backpack" 10, "Shirt" 5}]
    (println storage)
    (println "There are" (count storage) "elements")
    (println "The keys are:" (keys storage))
    (println "The values are:" (vals storage)))
  (let [storage {:backpack 10
                 :shirt    5}]
    (println storage)
    (println (assoc storage :chair 3))
    (println (assoc storage :backpack 1))
    (println (-> storage
                 :backpack))
    (println (-> storage
                 :shirt))))
