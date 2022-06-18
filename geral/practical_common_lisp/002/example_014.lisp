(defun new-cd (artist)
  (list :artist artist))

(defun select (cds predicate)
  (remove-if-not predicate cds))

(defun artist-predicate (artist)
  (lambda (cd) (equal (getf cd :artist) artist)))

(let ((cds nil))
  (push (new-cd "Linkin Park") cds)
  (push (new-cd "Guns N' Roses") cds)
  (select cds (artist-predicate "Linkin Park")))
