package main

import (
	"bytes"
	"io/ioutil"
	"mime/multipart"
	"net/http"
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
