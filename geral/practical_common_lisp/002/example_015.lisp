(defun foo (&key a b c)
  (list a b c))

(foo :a 10 :c 30 :b 20)
