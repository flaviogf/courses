(defun new-cd (artist title)
  (list :artist artist :title title))

(defun select (cds predicate)
  (remove-if-not predicate cds))

(defun where (&key artist title)
  (lambda (cd) (and
                (if artist (equal (getf cd :artist) artist) t)
                (if title (equal (getf cd :title) title) t))))

(defun dump (cds)
  (with-open-file (file "example_017.db" :direction :output :if-exists :supersede)
    (with-standard-io-syntax (print cds file))))

(let ((cds nil))
  (push (new-cd "Linkin Park" "In the end") cds)
  (push (new-cd "Guns N' Roses" "Welcome to the jungle") cds)
  (select cds (where :artist "Linkin Park"))
  (select cds (where :title "Welcome to the jungle"))
  (dump cds))
