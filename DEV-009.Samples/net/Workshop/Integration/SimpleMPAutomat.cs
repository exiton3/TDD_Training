using MPAutomat.Executor;
using MPAutomat.StateMachine;
using MPAutomat.Translator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAutomat.Tests.Integration
{
    class SimpleMPAutomat : AbstractMPAutomat
    {
        private CodeGenerator generator = new CodeGenerator();
        public override void InitGrammar()
        {
            stateMachine.AddJumper(new Jumper(' ', '!', 0, 0));
            stateMachine.AddJumper(new Jumper('\n', '!', 0, 0));

            //start of variable
            stateMachine.AddJumper(new Jumper('$', '!', "V", 0, 1, (x)=> { generator.put(x);
        }));
		
		//variable name. Only lower register
		String letters = "qwertyuiopasdfghjklzxcvbnm";
		
		foreach(char c in letters) {
			stateMachine.AddJumper(new Jumper(c,'V',1,1, (x) => { generator.put(x); }));
		}

        stateMachine.AddJumper(new Jumper(' ','V',"-O",1,2, (x) => { generator.setOperand(OperandType.VARIABLE); }));
		stateMachine.AddJumper(new Jumper(' ','O',2,2));
		
		//operator let
		stateMachine.AddJumper(new Jumper('=','V',"-",1,3,
                            (c) => { generator.setOperand(OperandType.VARIABLE); generator.setOperation(Instruction.STORE, -1); }
							));
		stateMachine.AddJumper(new Jumper('=','O',"-",2,3,
                            (c) => { generator.setOperation(Instruction.STORE, -1); }
							));
		//stateMachine.AddJumper(new Jumper('=','V',"-O",1,2));
		stateMachine.AddJumper(new Jumper(' ','!',3,3));
		
		
		//arithmetic operator
		stateMachine.AddJumper(new Jumper('+','O',"-",2,3, (x) => { generator.setOperation(Instruction.ADD, 1); }));
		stateMachine.AddJumper(new Jumper('-','O',"-",2,3, (x) => { generator.setOperation(Instruction.SUB, 1); }));
		stateMachine.AddJumper(new Jumper('*','O',"-",2,3, (x) => { generator.setOperation(Instruction.MUL, 2); }));
		stateMachine.AddJumper(new Jumper('/','O',"-",2,3, (x) => { generator.setOperation(Instruction.DIV, 2); }));
		
		stateMachine.AddJumper(new Jumper('+','V',"-",1,3, (x) => { generator.setOperation(Instruction.ADD, 1); }));
		stateMachine.AddJumper(new Jumper('-','V',"-",1,3, (x) => { generator.setOperation(Instruction.SUB, 1); }));
		stateMachine.AddJumper(new Jumper('*','V',"-",1,3, (x) => { generator.setOperation(Instruction.MUL, 2); }));
		stateMachine.AddJumper(new Jumper('/','V',"-",1,3, (x) => { generator.setOperation(Instruction.DIV, 2); }));
	
		//variable again
		stateMachine.AddJumper(new Jumper('$','!',"V",3,1, (x) => { generator.put(x); }));
	    //constant
		String consts = "0123456789";
		foreach(char c in consts) {
			stateMachine.AddJumper(new Jumper(c,'!',"C",3,4, (x) => { generator.put(x); }));
		}
		foreach(char c in consts) {
			stateMachine.AddJumper(new Jumper(c,'C',4,4, (x) => { generator.put(x); }));
		}
		//end of constant
		stateMachine.AddJumper(new Jumper(' ','C',"-O",4,2, (x) => { generator.setOperand(OperandType.CONST); }));
		stateMachine.AddJumper(new Jumper('$','C',"-V",4,1, (x) => { generator.setOperand(OperandType.CONST); generator.put(x); }));
		
		//arithmetic operator after constant
		stateMachine.AddJumper(new Jumper('+','C',"-",4,3,
                (x) => { generator.setOperand(OperandType.CONST); generator.setOperation(Instruction.ADD, 1); }));
		stateMachine.AddJumper(new Jumper('-','C',"-",4,3,
                (x) => { generator.setOperand(OperandType.CONST); generator.setOperation(Instruction.SUB, 1); }));
		stateMachine.AddJumper(new Jumper('*','C',"-",4,3,
                (x) => { generator.setOperand(OperandType.CONST); generator.setOperation(Instruction.MUL, 2); }));
		stateMachine.AddJumper(new Jumper('/','C',"-",4,3,
                (x) => { generator.setOperand(OperandType.CONST); generator.setOperation(Instruction.DIV, 2); }));
		
		//end of expression
		stateMachine.AddJumper(new Jumper(';','C',"-*!",4,0, (x) => { generator.setOperand(OperandType.CONST); }));
		stateMachine.AddJumper(new Jumper(';','V',"-*!",1,0, (x) => { generator.setOperand(OperandType.VARIABLE); }));

        }
        public override IList<Command> GetByteCode()
        {
            return generator.Generate();
        }
    }
}
