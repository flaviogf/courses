(defun new-cd (artist title)
  (list :artist artist :title title))

(defun select (cds predicate)
  (remove-if-not predicate cds))

(defun where (&key artist title)
  (lambda (cd) (and
                (if artist (equal (getf cd :artist) artist) t)
                (if title (equal (getf cd :title) title) t))))

(let ((cds nil))
  (push (new-cd "Linkin Park" "In the end") cds)
  (push (new-cd "Guns N' Roses" "Welcome to the jungle") cds)
  (select cds (where :artist "Linkin Park"))
  (select cds (where :title "Welcome to the jungle")))
