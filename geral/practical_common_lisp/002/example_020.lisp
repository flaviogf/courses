(defmacro backwards (expr) (reverse expr))

(backwards ("hello, world" t format))

(defun make-comparison-expr (field value)
  `(equal (getf cd ,field) ,value))

(make-comparison-expr :artist "Frank")

(defmacro where (field value)
  `(lambda (cd) ,(make-comparison-expr field value)))

(defun new-cd (artist)
  (list :artist artist))

(let ((cd (new-cd "Frank")))
  (print (funcall (where :artist "Wrong") cd))
  (print (funcall (where :artist "Frank") cd)))
