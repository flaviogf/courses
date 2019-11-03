@extends('layouts.app')

@section('content')
    <div class="row justify-content-center my-2">
        <div class="col col-12 col-md-8 col-lg-6 d-flex justify-content-end">
            <a href="{{ route('serie.create') }}" class="btn btn-dark">Add</a>
        </div>
    </div>

    <div class="row justify-content-center my-2">
        <div class="col col-12 col-md-8 col-lg-6">
            <table class="table table-striped table-bordered">
                <thead class="thead-dark">
                    <tr>
                        <th>Id</th>
                        <th>Name</th>
                    </tr>
                </thead>

                <tbody>
                    @foreach ($series as $serie)
                    <tr>
                        <td># {{ $serie->id }}</td>
                        <td>{{ $serie->name }}</td>
                    </tr>
                    @endforeach
                </tbody>
            </table>
        </div>
    </div>
@endsection
