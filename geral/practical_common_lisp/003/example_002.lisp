(defun print-yes-or-no (value)
  (if value (format t "yes") (format t "no")))

(print-yes-or-no nil)
(print-yes-or-no t)
