(defun make-cd (title artist rating ripped)
  (list :title title :artist artist :rating rating :ripped ripped))

(defvar *db* nil)

(defun append-record (cd)
  (push cd *db*))

(defun dump-db ()
  (format t "~{~{~a:~10t~a~%~}~%~}" *db*))
