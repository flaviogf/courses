<?php

class Document
{
    private string $value;

    public function __construct(string $value)
    {
        $this->value = $value;
    }
}