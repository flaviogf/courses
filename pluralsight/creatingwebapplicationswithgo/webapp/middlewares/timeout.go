package middlewares

import (
	"context"
	"net/http"
	"time"
)

type TimeoutMiddleware struct {
	Next http.Handler
}

func NewTimeoutMiddleware(next http.Handler) *TimeoutMiddleware {
	return &TimeoutMiddleware{next}
}

func (t *TimeoutMiddleware) ServeHTTP(w http.ResponseWriter, r *http.Request) {
	ctx, cancel := context.WithTimeout(r.Context(), 3*time.Second)

	defer cancel()

	cn := make(chan struct{})

	go func() {
		t.Next.ServeHTTP(w, r.WithContext(ctx))

		cn <- struct{}{}
	}()

	select {
	case <-cn:
		return
	case <-ctx.Done():
		w.WriteHeader(http.StatusRequestTimeout)
	}
}
