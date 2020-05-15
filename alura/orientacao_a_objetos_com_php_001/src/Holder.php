<?php

class Holder
{
    private string $name;
    private Document $document;

    public function __construct(string $name, Document $document)
    {
        $this->$name = $name;
        $this->document = $document;
    }
}