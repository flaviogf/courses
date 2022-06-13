(defun make-cd (artist title rating ripped)
  (list :artist artist :title title :rating rating :ripped ripped))

(defvar *db* nil)

(defun append-record (cd)
  (push cd *db*))

(defun dump-db ()
  (format t "~{~{~a:~10T~a~%~}~%~}" *db*))

(defun prompt-read (field)
  (format *query-io* "~a: " field)
  (finish-output *query-io*)
  (read-line *query-io*))

(defun prompt-for-cd ()
  (make-cd
   (prompt-read "artist")
   (prompt-read "title")
   (or (parse-integer (prompt-read "rating") :junk-allowed t) 0)
   (yes-or-no-p "ripped?")))

(defun add-cds ()
  (loop (append-record (prompt-for-cd))
   (unless (yes-or-no-p "another?") (return))))

(defun save-db (filename)
  (with-open-file (out filename :direction :output :if-exists :supersede)
    (with-standard-io-syntax (print *db* out))))
