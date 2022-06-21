(defmacro backwards (expr) (reverse expr))

(backwards ("hello, world" t format))

(defun make-comparison-expr (field value)
  (list 'equal (list 'getf field) value))

(make-comparison-expr :artist "Frank")
