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

(defun prompt-for-cd ()
  (make-cd
   (prompt-read "Artists")
   (prompt-read "Title")
   (prompt-read "Rating")
   (prompt-read "Ripped")))

(defun add-cds ()
  (loop
   (append-record (prompt-for-cd))
   (if (not (y-or-n-p "Another?: ")) (return))))
