(defmacro backwards (expr) (reverse expr))

(backwards ("hello, world" t format))

(defun make-comparison-expr (field value)
  `(equal (getf cd ,field) ,value))

(make-comparison-expr :artist "Frank")
