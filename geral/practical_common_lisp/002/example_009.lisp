(defun make-cd (artist title rating ripped)
  (list :artist artist :title title :rating rating :ripped ripped))

(defvar *db* nil)

(defun append-record (cd)
  (push cd *db*))

(defun dump-db ()
  (format t "~{~{a:~10t~a~%~}~}" *db*))

(defun prompt-read (prompt)
  (format *query-io* "~a: " prompt)
  (finish-output *query-io*)
  (read-line *query-io*))
