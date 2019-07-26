(ns forca.core)

(defn mult2 [x] (* x 2))

(defn pow3 [x] (* x (Math/pow 2 x)))

(def total-life 6)

(defn end-game [] (println "End Game"))

(defn missing-letters [words hits]
  (remove (fn [letter] (contains? hits (str letter))) words)
)

(defn hits-all-words? [words hits]
  (empty? (missing-letters words hits))
)

(defn game [number-life words hits]
  (if (= number-life 0)
    (end-game)
    (do
      (if (hits-all-words? words hits)
        (println "Win")
        (do
          (println "Play Game")
          (game (dec number-life) words hits)
        )
      )
    )
  )
)
