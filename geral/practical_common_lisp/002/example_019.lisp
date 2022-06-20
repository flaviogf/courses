(defun new-cd (artist)
  (list :artist artist))

(defun update (cds predicate &key artist)
  (mapcar (lambda (cd) (if (funcall predicate cd) (new-cd artist) cd)) cds))

(defun where (&key artist)
  (lambda (cd) (equal (getf cd :artist) artist)))

(let ((cds nil))
  (push (new-cd "Guns N' Roses") cds)
  (push (new-cd "Imagine Dragons") cds)
  (update cds (where :artist "Guns N' Roses") :artist "Linkin Park"))
