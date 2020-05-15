<?php

namespace Bank\Models;

class Person
{
    private string $name;
    private Document $document;

    public function __construct(string $name, Document $document)
    {
        $this->name = $name;
        $this->document = $document;
    }

    public function getName(): string
    {
        return $this->name;
    }

    public function getDocument(): string
    {
        return $this->document->getValue();
    }
}