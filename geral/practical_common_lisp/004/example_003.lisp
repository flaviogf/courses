(defun foo (a b &optional c)
  (list a b c))

(defun print-list (l)
  (dolist (i l)
    (format t "Number: ~d~%" i)))
  

(print-list (foo 1 2))
(print-list (foo 1 2 3))
