cmake_minimum_required(VERSION 3.15)
project(test)

find_package(OpenGL REQUIRED)
find_package(GLUT REQUIRED)
find_package(Assimp REQUIRED)
include_directories(${OPENGL_INCLUDE_DIR})
include_directories(${GLUT_INCLUDE_DIR})
include_directories(${ASSIMP_INCLUDE_DIR})


set(CMAKE_CXX_STANDARD 14)

add_executable(test main.cpp utils/glad.c)
add_executable(1.1 HelloTriangle/HelloTriangle_1.cpp utils/glad.c)
add_executable(1.2 HelloTriangle/HelloTriangle_2.cpp utils/glad.c)
add_executable(1.3 HelloTriangle/HelloTriangle_3.cpp utils/glad.c)
add_executable(2.1 Shader/Shader_1.cpp utils/glad.c)
add_executable(2.2 Shader/Shader_2/Shader_2.cpp utils/glad.c)
add_executable(2.3 Shader/Shader_3/Shader_3.cpp utils/glad.c)
add_executable(3.1 Texture/sample/sample.cpp utils/glad.c utils/stb_image.h)
add_executable(3.2 Texture/Texture_1/Texture_1.cpp utils/glad.c utils/stb_image.h)
add_executable(3.3 Texture/Texture_2/Texture_2.cpp utils/glad.c utils/stb_image.h)
add_executable(5.3 Texture/Texture_3/Texture_3.cpp utils/glad.c utils/stb_image.h)
add_executable(6.3 Texture/Texture_4/Texture_4.cpp utils/glad.c utils/stb_image.h)
add_executable(4.1 Transformation/sample/sample.cpp utils/glad.c utils/stb_image.h)
add_executable(4.2 Transformation/Trans_1/Transformation_1.cpp utils/glad.c utils/stb_image.h)
add_executable(4.3 Transformation/Trans_2/Transformation_2.cpp utils/glad.c utils/stb_image.h)
add_executable(5.1 CoordinateSystem/sample/sample.cpp utils/glad.c utils/stb_image.h)
add_executable(5.2 CoordinateSystem/coordinate_1/coordinate_1.cpp utils/glad.c utils/stb_image.h)
add_executable(6.1 Camera/sample/sample.cpp utils/glad.c utils/stb_image.h utils/camera.h)
add_executable(6.2 Camera/Camera_1/camera_1.cpp utils/glad.c utils/stb_image.h utils/camera.h)
add_executable(7.1 Colors/sample/sample.cpp utils/glad.c utils/stb_image.h utils/camera.h)
add_executable(7.2 BasicLighting/sample/sample.cpp utils/glad.c utils/stb_image.h utils/camera.h)
add_executable(7.3 BasicLighting/lighting_1/lighting_1.cpp utils/glad.c utils/stb_image.h utils/camera.h)
add_executable(8.1 Material/sample/sample.cpp utils/glad.c utils/stb_image.h utils/camera.h)
add_executable(8.2 LightingMaps/sample/sample.cpp utils/glad.c utils/stb_image.h utils/camera.h)
add_executable(8.3 LightingMaps/maps_1/maps_1.cpp utils/glad.c utils/stb_image.h utils/camera.h)
add_executable(9.1 LightingMaps/maps_2/maps_2.cpp utils/glad.c utils/stb_image.h utils/camera.h)
add_executable(9.2 LightingMaps/maps_3/maps_3.cpp utils/glad.c utils/stb_image.h utils/camera.h)
add_executable(9.3 LightCaster/flashLight/flashLight.cpp utils/glad.c utils/stb_image.h utils/camera.h)
add_executable(10.1 LightCaster/pointLight/pointLight.cpp utils/glad.c utils/stb_image.h utils/camera.h)
add_executable(10.2 LightCaster/parallel/parallel.cpp utils/glad.c utils/stb_image.h utils/camera.h)
add_executable(10.3 MultipleLights/sample/sample.cpp utils/glad.c utils/stb_image.h utils/camera.h)
add_executable(11.1 Mesh/sample/sample.cpp utils/glad.c utils/stb_image.h utils/camera.h)
add_executable(11.2 Model/sample/sample.cpp utils/glad.c utils/stb_image.h utils/camera.h utils/mesh.h utils/model.h)


# specify the search location
set( _glfw3_HEADER_SEARCH_DIRS "/usr/local/include")
set( _glfw3_LIB_SEARCH_DIRS "/usr/local/lib")
set( glm_dirs "./glm")
set( _assimp_LIB_SEARCH_DIRS "/usr/local/Cellar/assimp/5.0.1/lib")

set( _glfw3_ENV_ROOT $ENV{GLFW3_ROOT} )
if( NOT GLFW3_ROOT AND _glfw3_ENV_ROOT )
    set(GLFW3_ROOT ${_glfw3_ENV_ROOT} )
endif()

# Put user specified location at beginning of search
if( GLFW3_ROOT )
    list( INSERT _glfw3_HEADER_SEARCH_DIRS 0 "${GLFW3_ROOT}/include" )
    list( INSERT _glfw3_LIB_SEARCH_DIRS 0 "${GLFW3_ROOT}/lib" )
endif()

# Search for the header
FIND_PATH(GLFW3_INCLUDE_DIR "GLFW/glfw3.h" PATHS ${_glfw3_HEADER_SEARCH_DIRS})

# Search for the library
FIND_LIBRARY(GLFW3_LIBRARY NAMES libglfw.3.4.dylib PATHS ${_glfw3_LIB_SEARCH_DIRS})
FIND_LIBRARY(ASSIMP_LIBRARY NAMES libassimp.5.0.0.dylib PATHS ${_assimp_LIB_SEARCH_DIRS})

#include header file directory
include_directories(${GLFW3_INCLUDE_DIR})
include_directories(${glm_dirs})
include_directories("./")

#include library file directory
link_directories(${_glfw3_LIB_SEARCH_DIRS})

#link library file
target_link_libraries(test ${GLFW3_LIBRARY})

foreach(i RANGE 1 10)
    foreach(j RANGE 1 3)
        target_link_libraries(${i}.${j} ${GLFW3_LIBRARY})
    endforeach()
endforeach()
target_link_libraries(11.1 ${GLFW3_LIBRARY})
target_link_libraries(11.2 ${GLFW3_LIBRARY} ${ASSIMP_LIBRARY})


