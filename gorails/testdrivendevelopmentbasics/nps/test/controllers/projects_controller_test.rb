require "test_helper"

class ProjectsControllerTest < ActionDispatch::IntegrationTest
  setup do
    sign_in users(:regular)

    @project = projects(:one)
  end

  test 'redirected if not logged' do
    sign_out :user

    get projects_url

    assert_response :redirect
  end

  test 'can get index' do
    get projects_url

    assert_response :success
  end

  test 'can get new' do
    get new_project_url

    assert_response :success
  end

  test 'can create a project' do
    assert_difference('Project.count') do
      post projects_url, params: { project: { title: 'New Project' } }
    end

    assert_redirected_to Project.last
  end

  test 'can view project' do
    get project_url(@project)

    assert_response :success
  end

  test 'can edit project' do
    get edit_project_url(@project)

    assert_response :success
  end

  test 'can update project' do
    put project_url(@project), params: { project: { title: 'Updated Project' } }

    assert_redirected_to @project

    @project.reload

    assert_equal 'Updated Project', @project.title
  end

  test 'cannot update project with invalid attributes' do
    put project_url(@project), params: { project: { title: '' } }

    assert_response :unprocessable_entity
  end

  test 'can destroy project' do
    assert_difference('Project.count', -1) do
      delete project_url(@project)
    end

    assert_redirected_to projects_url
  end
end
