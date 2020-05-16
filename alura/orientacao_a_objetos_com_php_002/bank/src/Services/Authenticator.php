<?php

namespace Bank\Services;

use Bank\Models\Authenticable;

class Authenticator
{
    public function attempt(Authenticable $authentic, string $password): bool
    {
        return $authentic->attempt($password);
    }
}