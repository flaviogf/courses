(defun new-cd (artist)
  (list :artist artist))

(defun select (cds predicate)
  (remove-if-not predicate cds))

(defun where (&key artist)
  (lambda (cd) (if artist (equal (getf cd :artist) artist) t)))

(let ((cds nil))
  (push (new-cd "Linkin Park") cds)
  (push (new-cd "Guns N' Roses") cds)
  (select cds (where :artist "Linkin Park")))
