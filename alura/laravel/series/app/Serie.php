<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class Serie extends Model
{
    protected $fillable = ['name'];

    public function seasons()
    {
        return this.hasMany('App\Seasons');
    }
}
