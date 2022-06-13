(defun print-even-numbers ()
  (remove-if-not #'evenp '(1 2 3 4 5 6 7 8 9 10)))
