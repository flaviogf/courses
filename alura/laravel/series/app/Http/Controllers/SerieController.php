<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Serie;

class SerieController extends Controller
{
    public function index()
    {
        $series = Serie::all();

        return view('serie.index', [
            'series' => $series
        ]);
    }

    public function create()
    {

        return view('serie.create');
    }

    public function store(Request $request)
    {
        $serie = Serie::create([
            'name' => $request->input('name')
        ]);

        return redirect(route('serie.index'));
    }
}
