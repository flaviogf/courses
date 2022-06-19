(defun times (x)
  (lambda (y) (* x y)))

(let ((numbers (list 1 2 3 4 5 6 7 8 9 10)))
  (print numbers)
  (print (mapcar (lambda (n) (funcall (times 10) n)) numbers)))
