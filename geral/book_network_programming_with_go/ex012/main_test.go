package main

import (
	"bytes"
	"fmt"
	"io"
	"io/ioutil"
	"mime/multipart"
	"net/http"
	"os"
	"path/filepath"
	"testing"
	"time"
)

func TestMultipartPost(t *testing.T) {
	body := &bytes.Buffer{}
	w := multipart.NewWriter(body)

	for k, v := range map[string]string{
		"date":        time.Now().Format(time.RFC3339),
		"description": "Form values with attached files",
	} {
		w.WriteField(k, v)
	}

	for i, file := range []string{
		"./hello.txt",
		"./goodbye.txt",
	} {
		filePart, err := w.CreateFormFile(fmt.Sprintf("file%d", i+1), filepath.Base(file))

		if err != nil {
			t.Fatal(err)
		}

		f, err := os.Open(file)

		if err != nil {
			t.Fatal(err)
		}

		_, err = io.Copy(filePart, f)

		if err != nil {
			t.Fatal(err)
		}
	}

	err := w.Close()

	if err != nil {
		t.Fatal(err)
	}

	req, err := http.NewRequest(http.MethodPost, "https://httpbin.org/post", body)

	if err != nil {
		t.Fatal(err)
	}

	resp, err := http.DefaultClient.Do(req)

	if err != nil {
		t.Fatal(err)
	}

	bytes, err := ioutil.ReadAll(resp.Body)

	if err != nil {
		t.Fatal(err)
	}

	t.Log(string(bytes))
}
