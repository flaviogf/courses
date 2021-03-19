package middlewares

import (
	"compress/gzip"
	"io"
	"net/http"
	"strings"
)

type GzipMiddleware struct {
	Next http.Handler
}

func NewGzipMiddleware(next http.Handler) *GzipMiddleware {
	return &GzipMiddleware{next}
}

func (g *GzipMiddleware) ServeHTTP(w http.ResponseWriter, r *http.Request) {
	encoding := r.Header.Get("Accept-Encoding")

	if !strings.Contains(encoding, "gzip") {
		g.Next.ServeHTTP(w, r)
		return
	}

	w.Header().Add("Content-Encoding", "gzip")

	gzipwriter := gzip.NewWriter(w)

	defer gzipwriter.Close()

	gwr := gzipResponseWriter{
		ResponseWriter: w,
		Writer:         gzipwriter,
	}

	g.Next.ServeHTTP(gwr, r)
}

type gzipResponseWriter struct {
	http.ResponseWriter
	io.Writer
}

func (gwr gzipResponseWriter) Write(p []byte) (n int, err error) {
	return gwr.Writer.Write(p)
}
