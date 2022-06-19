(defun foo (&key a (b 20) (c 30 c-p))
  (list a b c c-p))

(foo :a 10 :b 40 :c 50)
(foo :a 10 :c 50)
(foo :a 10)
