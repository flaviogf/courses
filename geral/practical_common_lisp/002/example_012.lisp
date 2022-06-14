(defun print-even-numbers ()
  (remove-if-not (lambda (x) (= 0 (mod x 2))) '(1 2 3 4 5 6 7 8 9 10)))
