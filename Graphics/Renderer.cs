using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;

namespace Graphics
{
    class Renderer
    {
        Shader sh;
        uint vertexBufferID;
        public void Initialize()
        {
            string projectPath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            sh = new Shader(projectPath + "\\Shaders\\SimpleVertexShader.vertexshader", projectPath + "\\Shaders\\SimpleFragmentShader.fragmentshader");
            Gl.glClearColor(1, 0, 0, 1);
            float[] verts = { 
		
		        // 1-  A			  point index
		        //-----
		        -0.7f,  0.85f, 0.0f,     //0
		        -0.65f,  0.95f, 0.0f,     //1
                -0.6f,  0.85f,  0.0f,   //2
                -0.63f,  0.9f,  0.0f,   //3
                -0.68f,  0.9f,  0.0f,   //4

		        // 2 - STAR
		        //----------
		        -0.7f, 0.8f, 0.0f,      //5
		        -0.75f, 0.8f, 0.0f,     //6
		        -0.75f, 0.75f, 0.0f,    //7
			    -0.7f,  0.75f,  0.0f,   //8
                -0.7f,  0.7f,  0.0f,     //9
                -0.75f,  0.7f,  0.0f,    //10

                -0.65f,  0.8f,  0.0f,    //11
                -0.6f,  0.8f,  0.0f,     //12
                -0.625f,  0.8f,  0.0f,  //13
                -0.625f,  0.7f,  0.0f,  //14

                -0.55f,  0.7f,  0.0f,   //15
                -0.5f,  0.8f,  0.0f,    //16
                -0.45f, 0.7f,  0.0f,    //17
                -0.48f,  0.75f,  0.0f,  //18
                -.53f,  0.75f,  0.0f,   //19

                -0.4f,  0.7f,  0.0f,    //20
                -0.4f,  0.8f,  0.0f,   //21
                -0.35f,  0.8f,  0.0f,   //22
                -0.35f,  0.75f,  0.0f,  //23
                -0.4f,0.75f,0.0f,   //24
                -0.35f,0.7f,0.0f,   //25

                //3 - IS
                -0.4f,0.55f,0.0f,   //26
                -0.4f,0.65f,0.0f,   //27

                -0.35f,0.55f,0.0f,  //28
                -0.3f,0.55f,0.0f,   //29
                -0.3f,0.6f,0.0f,    //30
                -0.35f,0.6f,0.0f,   //31
                -0.35f,0.65f,0.0f,  //32
                -0.3f,0.65f,0.0f,   //33

                //4 - BORN
                -0.5f,0.4f,0,   //34
                -0.45f,0.4f,0,  //35
                -0.45f,0.45f,0, //36
                -0.5f,0.45f,0,  //37
                -0.5f,0.45f,0,  //38
                -0.45f,0.45f,0, //39
                -0.45f,0.5f,0,  //40
                -0.5f,0.5f,0,   //41                

                -0.41f,0.44f,0, //42
                -0.39f,0.47f,0, //43
                -0.35f,0.47f,0, //44
                -0.33f,0.44f,0, //45
                -0.35f,0.42f,0, //46
                -0.39f,0.42f,0, //47

                -0.3f,0.4f,0,   //48
                -0.3f,0.5f,0,   //49
                -0.25f,0.5f,0,  //50
                -0.25f,0.45f,0, //51
                -0.3f,0.45f,0,  //52
                -0.25f,0.4f,0,  //53

                -0.2f,0.4f,0,   //54
                -0.2f,0.5f,0,   //55
                -0.2f,0.5f,0,   //56
                -0.15f,0.4f,0,  //57
                -0.15f,0.4f,0,  //58
                -0.15f,0.5f,0,  //59

                //5 - right Hand
                0.30f,0.50f,0,    //60
                -0.10f,0.50f,0,   //61
                -0.05f,0.45f,0,   //62
                -0.10f,0.50f,0,   //63
                -0.05f,0.55f,0,   //64

                //6 - left Hand
                0.50f,0.50f,0,    //65
                0.70f,0.50f,0,    //66
                0.70f,0.40f,0,    //67
                0.65f,0.45f,0,    //68
                0.70f,0.40f,0,    //69
                0.75f,0.45f,0,    //70

                //7 - body
                0.30f,0.30f,0,    //71
                0.50f,0.30f,0,    //72
                0.50f,0.55f,0,    //73
                0.30f,0.30f,0,    //74
                0.50f,0.55f,0,    //75
                0.30f,0.55f,0,    //76

                //8 - left leg
                0.30f,0.25f,0,    //77    
                0.40f,0.25f,0,    //78
                0.35f,0.30f,0,    //79

                //9 - right leg
                0.40f,0.25f,0,    //80
                0.50f,0.25f,0,    //81
                0.45f,0.30f,0,    //82

                //10 - neck
                0.40f,0.55f,0,    //83
                0.40f,0.60f,0,    //84

                //11 - head
                0.35f,0.60f,0,    //85
                0.45f,0.60f,0,    //86
                0.45f,0.65f,0,    //87
                0.35f,0.65f,0,    //88

                //12 - eyes
                0.38f,0.635f,0,    //89
                0.42f,0.635f,0,    //90

                //13 - mouth
                0.4f,0.61f,0,   //91
                0.39f,0.62f,0,  //92
                0.4f,0.61f,0,   //93
                0.41f,0.62f,0,  //94

                //14 - ZIKO
                -0.65f,0.65f,0, //95
                -0.6f,0.65f,0,  //96
                -0.65f,0.6f,0,  //97
                -0.6f,0.6f,0,    //98

                -0.56f,0.65f,0, //99
                -0.54f,0.65f,0, //100
                -0.55f,0.65f,0, //101
                -0.55f,0.6f,0,  //102
                -0.56f,0.6f,0,  //103
                -0.54f,0.6f,0,  //104

                -0.5f,0.6f,0,   //105
                -0.5f,0.65f,0,  //106
                -0.5f,0.63f,0,  //107
                -0.47f,0.65f,0, //108
                -0.5f,0.63f,0,  //109
                -0.47f,0.6f,0,  //110

                -0.46f,0.62f,0, //111
                -0.45f,0.61f,0,  //112
                -0.43f,0.61f,0, //113
                -0.42f,0.62f,0, //114
                -0.43f,0.64f,0, //115
                -0.45f,0.64f,0,  //116

                //15 - Comming
                0.58f,0.35f,0,  //117
                0.55f,0.35f,0,  //118
                0.55f,0.3f,0,   //119
                0.58f,0.3f,0,   //120

                0.6f,0.35f,0,   //121
                0.6f,0.3f,0,    //122
                0.65f,0.3f,0,   //123
                0.65f,0.35f,0,  //124

                0.68f,0.3f,0,   //125
                0.68f,0.35f,0,  //126
                0.7f,0.33f,0,   //127
                0.72f,0.35f,0,  //128
                0.72f,0.3f,0,   //129

                0.74f,0.3f,0,   //130
                0.74f,0.35f,0,  //131
                0.76f,0.33f,0,  //132
                0.78f,0.35f,0,  //133
                0.78f,0.3f,0,   //134

                0.79f,0.35f,0,  //135
                0.81f,0.35f,0,  //136
                0.8f,0.35f,0,   //137
                0.8f,0.3f,0,    //138
                0.79f,0.3f,0,   //139
                0.81f,0.3f,0,   //140

                0.83f,0.3f,0,   //141
                0.83f,0.35f,0,  //142
                0.85f,0.3f,0,   //143
                0.85f,0.35f,0,  //144

                0.9f,0.33f,0,   //145
                0.9f,0.35f,0,   //146
                0.87f,0.35f,0,  //147
                0.87f,0.3f,0,   //148
                0.9f,0.3f,0,    //149
                0.9f,0.32f,0,   //150
                0.89f,0.32f,0,   //151

                // 16 - Soon
                0.65f,0.25f,0,  //152
                0.6f,0.25f,0,   //153
                0.6f,0.2f,0,    //154
                0.65f,0.2f,0,   //155
                0.65f,0.15f,0,  //156
                0.6f,0.15f,0,   //157

                0.69f,0.23f,0,  //158
                0.69f,0.18f,0,  //159
                0.72f,0.18f,0,  //160
                0.72f,0.23f,0,  //161

                0.75f,0.23f,0,  //162
                0.75f,0.18f,0,  //163
                0.78f,0.18f,0,  //164
                0.78f,0.23f,0,  //165

                0.83f,0.15f,0,  //166
                0.83f,0.25f,0,  //167
                0.88f,0.15f,0,  //168
                0.88f,0.25f,0   //169

            };
            vertexBufferID = GPU.GenerateBuffer(verts);
        }

        public void Draw()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glEnableVertexAttribArray(0);
            Gl.glVertexAttribPointer(0, 3, Gl.GL_FLOAT, Gl.GL_FALSE, 0, IntPtr.Zero);


            //// Draw your primitives !
            Gl.glPointSize(2);

            //// 1 - A
            Gl.glDrawArrays(Gl.GL_LINE_STRIP,0,5);

            //// 2 - STAR
            Gl.glDrawArrays(Gl.GL_LINE_STRIP, 5, 6);
            Gl.glDrawArrays(Gl.GL_LINE_STRIP, 11, 4);
            Gl.glDrawArrays(Gl.GL_LINE_STRIP, 15, 5);
            Gl.glDrawArrays(Gl.GL_LINE_STRIP, 20, 6);

            //// 3 - IS
            Gl.glDrawArrays(Gl.GL_LINE_STRIP, 26, 2);
            Gl.glDrawArrays(Gl.GL_LINE_STRIP, 28, 6);

            //// 4 - BORN
            Gl.glDrawArrays(Gl.GL_LINE_LOOP, 34, 4);
            Gl.glDrawArrays(Gl.GL_LINE_LOOP, 38, 4);
            Gl.glDrawArrays(Gl.GL_LINE_LOOP, 42, 6);
            Gl.glDrawArrays(Gl.GL_LINE_STRIP, 48, 6);
            Gl.glDrawArrays(Gl.GL_LINES, 54, 6);
            
            //// 5 - Arms
            Gl.glDrawArrays(Gl.GL_LINE_STRIP, 60, 3);
            Gl.glDrawArrays(Gl.GL_LINES, 63, 2);
            Gl.glDrawArrays(Gl.GL_LINE_STRIP, 65, 4);
            Gl.glDrawArrays(Gl.GL_LINES, 69, 2);

            //// 6 - body
            Gl.glDrawArrays(Gl.GL_TRIANGLE_STRIP,71,6);
            Gl.glColor3b(146, 21, 37);
            //// 7 - Leg
            Gl.glDrawArrays(Gl.GL_TRIANGLES,77,6);

            //// 8 - neck
            Gl.glDrawArrays(Gl.GL_LINES,83,2);

            //// 9 - Head
            Gl.glDrawArrays(Gl.GL_LINE_LOOP, 85, 4);

            //// 10 -  Eyes        
            Gl.glDrawArrays(Gl.GL_POINTS, 89, 2);

            //// 11 - Mouth
            Gl.glDrawArrays(Gl.GL_LINES,91,4);

            //// 12 - Ziko
            Gl.glDrawArrays(Gl.GL_LINE_STRIP, 95, 4);
            Gl.glDrawArrays(Gl.GL_LINES, 99, 6);
            Gl.glDrawArrays(Gl.GL_LINES, 105, 6);
            Gl.glDrawArrays(Gl.GL_LINE_LOOP, 111, 6);
            
            // 13 - Comming
            Gl.glDrawArrays(Gl.GL_LINE_STRIP, 117, 4);
            Gl.glDrawArrays(Gl.GL_LINE_LOOP, 121, 4);
            Gl.glDrawArrays(Gl.GL_LINE_STRIP, 125, 5);
            Gl.glDrawArrays(Gl.GL_LINE_STRIP, 130, 5);
            Gl.glDrawArrays(Gl.GL_LINES, 135, 6);
            Gl.glDrawArrays(Gl.GL_LINE_STRIP, 141, 4);
            Gl.glDrawArrays(Gl.GL_LINE_STRIP, 145, 7);

            // 14 - Soon
            Gl.glDrawArrays(Gl.GL_LINE_STRIP, 152, 6);
            Gl.glDrawArrays(Gl.GL_LINE_LOOP, 158, 4);
            Gl.glDrawArrays(Gl.GL_LINE_LOOP, 162, 4);
            Gl.glDrawArrays(Gl.GL_LINE_STRIP, 166, 4);

            Gl.glDisableVertexAttribArray(0);
        }
        public void Update()
        {

        }
        public void CleanUp()
        {
            sh.DestroyShader();
        }
    }
}
