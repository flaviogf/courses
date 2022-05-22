(defun make-cd (title artist rating ripped)
  (list :title title :artist artist :rating rating :ripped ripped))

(defun print-cd (cd)
  (format t "~{~a:~10t~a~%~}" cd))
