(defun new-cd (artist title rating ripped)
  (list :artist artist :title title :rating rating :ripped ripped))

(defun print-cd (cd)
  (format t "Artist: ~a, Title: ~a, Rating: ~a, Ripped: ~a~%"
                           (getf cd :artist)
                           (getf cd :title)
                           (getf cd :rating)
                           (getf cd :ripped)))

(defun print-cds (cds)
  (dolist (cd cds) (print-cd cd)))

(defun select-by-artist (cds artist)
  (remove-if-not (lambda (cd) (equal (getf cd :artist) artist)) cds))

(let ((cds nil))
  (push (new-cd "Linkin Park" "Meteora" 10 t) cds)
  (push (new-cd "Guns N' Roses" "Appetite for Destruction" 10 t) cds)
  (print-cds cds)
  (print-cds (select-by-artist cds "Guns N' Roses")))
